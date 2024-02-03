namespace Svg2Any.Queue
{
    public class Worker
    {
        public static readonly List<Workload> workloads = new List<Workload>();
        private Thread? executeThread = null;

        public event EventHandler<WorkerStatusEnum>? StatusChanged;

        public enum WorkerStatusEnum
        {
            Stopped = 1,
            Starting = 2,
            Running = 3,
            Stopping = 4
        }

        public static void Enqueue(Workload workload)
        {
            workloads.Add(workload);
        }

        private static Workload? Dequeue()
        {
            var workload = workloads.OrderBy(w => w.RunAfter).FirstOrDefault();
            if (workload != null)
                workloads.Remove(workload);
            return workload;
        }

        public void Start()
        {
            if (!IsRunning)
            {
                StatusChanged?.Invoke(this, WorkerStatusEnum.Starting);
                IsRunning = true;
                executeThread = new Thread(Execute);
                executeThread.Start();
            }
        }

        private void Execute()
        {
            try
            {
                StatusChanged?.Invoke(this, WorkerStatusEnum.Running);
                while (!CancelRequested)
                {
                    int wait = 0;
                    var workload = Dequeue();
                    if (workload != null)
                    {
                        var now = DateTime.Now;
                        if (workload.RunAfter <= now)
                        {
                            if (workload.Run() == Workload.ExecutionResultEnum.Retry)
                                Enqueue(workload);
                        }
                        wait = Math.Min(Convert.ToInt32(now.Subtract(workload.RunAfter).TotalMilliseconds), 1000);
                    }
                    else
                        wait = 1000;

                    if (wait < 0)
                        wait = 0;

                    Thread.Sleep(wait);
                }
            }
            catch (Exception)
            {

            }
            IsRunning = false;
            StatusChanged?.Invoke(this, WorkerStatusEnum.Stopped);
        }

        public void Stop()
        {
            if (IsRunning)
            {
                StatusChanged?.Invoke(this, WorkerStatusEnum.Stopping);
                CancelRequested = true;
                while (IsRunning)
                {
                    Thread.Sleep(300);
                }
                if (executeThread != null && executeThread.IsAlive)
                    executeThread.Join();
            }
        }

        public bool IsRunning { get; private set; } = false;
        public bool CancelRequested { get; private set; } = false;
    }
}
