using System.Diagnostics;

namespace PrismBox
{
	public partial class PrismBox : Mod
	{
		public static PrismBox Instance => ModContent.GetInstance<PrismBox>();

		public static void FormatToLogs(Mod mod, string msg, LogType type, StackTrace st = null)
		{
			switch (type) 
			{
				case LogType.INFO:
					mod.Logger.Info("[prismBox]: " + msg);
					break;
				case LogType.DEBUG:
                    mod.Logger.Debug("[prismBox]: " + msg);
                    break;
				case LogType.WARN:
					mod.Logger.Warn("[prismBox]: " + msg);
					break;
				case LogType.ERROR:
					mod.Logger.Error("[prismBox]: " + msg + " at: " + st);
					break;
				case LogType.FATAL:
                    mod.Logger.Fatal("[prismBox]: " + msg + " at: " + st);
                    break;
			}
		}

        public override void Load()
        {
			FormatToLogs(Instance, "This mod was created with PrismBox", LogType.INFO);

            base.Load();
        }

        public enum LogType
		{
			INFO,
			DEBUG,
			WARN,
			ERROR,
			FATAL
		}
	}
}