using System.Configuration;

namespace ExportDanych.Configuration
{
    internal class BaseCatalogDir : ConfigurationSection
    {
        private const string BaseDirKey = "directory";

        [ConfigurationProperty(BaseDirKey, IsRequired = true)]
        public string BaseDir
        {
            get { return (string)this[BaseDirKey]; }
            set { this[BaseDirKey] = value; }
        }
    }
}