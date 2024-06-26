﻿namespace SoruxBot.Kernel.Interface
{
    /// <summary>
    /// 存储插件信息
    /// </summary>
    public interface IPluginsStorage
    {
        /// <summary>
        /// 如果想要注册的插件其对应的名称存在（名称为主键），那么就返回失败且不允许插件注册。
        /// 由于名称为包名，在名称相同的情况下我们更认为是插件的不同版本的重复注册。
        /// 在插件的注册中，会直接确定插件的优先级顺序。
        /// </summary>
        /// <param name="name"></param>
        /// <param name="author"></param>
        /// <param name="filename"></param>
        /// <param name="version"></param>
        /// <param name="description"></param>
        /// <param name="privilege"></param>
        /// <param name="isUpperWhenPrivilege"></param>
        /// <returns></returns>
        bool AddPlugin(
            string name, 
            string author, 
            string filename, 
            string version, 
            string description, 
            int privilege,
            bool isUpperWhenPrivilege
            );

        /// <summary>
        /// 移除一个插件，表示的是将插件在内存中移除，而不是物理上移除
        /// </summary>
        /// <param name="name"></param>
        void RemovePlugin(string name);

        /// <summary>
        /// 移除所有的插件，表示的是将所有插件在内存中移除，而不是物理上的移除
        /// </summary>
        void RemoveAllPlugins();

        /// <summary>
        /// 得到指定插件的作者名称，失败则返回 Null
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string? GetAuthor(string name);

        /// <summary>
        /// 得到指定插件的文件名称，失败则返回 Null
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string? GetFileName(string name);

        /// <summary>
        /// 得到指定插件的版本名称，失败则返回 Null
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string? GetVersion(string name);

        /// <summary>
        /// 得到指定插件的描述信息，失败则返回 Null
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string? GetDescription(string name);

        /// <summary>
        /// 得到指定插件的优先级，失败则返回 Null
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int? GetPrivilege(string name);

        /// <summary>
        /// 得到指定优先级的插件名称，没有则返回 Null
        /// </summary>
        /// <param name="privilege"></param>
        /// <returns></returns>
        public IEnumerable<string>? GetPluginByPrivilege(int privilege);
        
        /// <summary>
        /// 判断插件是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsExists(string name);

        /// <summary>
        /// 设置插件的内部设置信息，如果发现 name + key 已有字段，将替换原来的字段
        /// </summary>
        /// <param name="name"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public bool SetPluginInformation(string name, string key, string value);

        /// <summary>
        /// 得到插件的内部设置信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="key"></param>
        public string? GetPluginInformation(string name, string key);

        /// <summary>
        /// 尝试获取插件的内部设置信息，如果插件名称错误，那么返回 False
        /// </summary>
        /// <param name="name"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TryGetPluginInformation(string name, string key, out string? value);

        /// <summary>
        /// 存储插件实例
        /// </summary>
        /// <param name="name"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        public bool SetPluginInstance(string name, object instance);

        /// <summary>
        /// 取出插件实例
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object GetPluginInstance(string name);

        /// <summary>
        /// 尝试取出插件实例，如果插件名称错误，那么返回 False
        /// </summary>
        /// <param name="name"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        public bool TryGetPluginInstance(string name, out object instance);
		/// <summary>
		/// 获取按照优先级排序的插件名称
		/// </summary>
		/// <returns></returns>
		public List<string> GetPluginsOrderedByPrivilegeAsc();
    }
}