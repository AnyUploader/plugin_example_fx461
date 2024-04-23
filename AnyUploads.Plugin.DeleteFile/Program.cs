using System.IO;

namespace AnyUploads.Plugin.DeleteFile
{
    //生成控制台进行调试程序
    //生成类库进行发布插件
    //如果引入第三方插件,请合并程序集
    internal class Program
    {
        static void Main(string[] args)
        {
            //debug plugin|调试插件
            var plugin = new DeleteFilePlugin();
            plugin.SetData(new FileInfo(""));
            plugin.Execute();
        }
    }


    public class DeleteFilePlugin : PluginBase
    {
        public override string Name => "删除文件插件";
        public override string Id => "anyuploads.plugin.deletefile";
        public override string Author => "AnyUploads";
        public override string Description => "Delete file";

        //插件配置|pluginconfig
        //public override Dictionary<string, string> PluginConfig => new Dictionary<string, string>
        //{
        //    ["your_config_key"] = ""
        //};

        public override void Execute()
        {
            var your_config_value = Paramater.GetExt<string>("your_config_key");
            var fileInfo = Data as FileInfo;

            if (File.Exists(fileInfo.FullName))
            {
                File.Delete(fileInfo.FullName);
                Logger.Info($"文件已删除->{fileInfo.Name}");
            }
        }
    }
}
