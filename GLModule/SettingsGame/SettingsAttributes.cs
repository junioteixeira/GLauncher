using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace GLModule.SettingsGame
{
    /// <summary>
    /// Informa se a configuração de registro será salva em LocalMachine ou CurrentUser
    /// </summary>
    public enum TypeRegistryLocal
    {
        LocalMachine,
        CurrentUser
    };

    /// <summary>
    /// Informa que certa propriedade não é uma configuração, ou seja, será ignorada pelo código
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public sealed class NonConfigAttribute : System.Attribute { };

    /// <summary>
    /// Informa que a propriedade será gravada no registro
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public sealed class RegisterConfigAttribute : System.Attribute 
    {
        /// <summary>
        /// Informa se o a configuração será salva em LocalMachine ou CurrentUser
        /// </summary>
        public TypeRegistryLocal RegistryLocal { get; private set; }

        /// <summary>
        /// Local onde será salva a chave
        /// </summary>
        public string Path { get; private set; }

        public RegisterConfigAttribute()
        { }

        /// <summary>
        /// Informa que a propriedade será gravada no registro
        /// </summary>
        /// <param name="RegistryLocal">Informa se o a configuração será salva em LocalMachine ou CurrentUser</param>
        /// <param name="Path">Local onde será salva a chave</param>
        public RegisterConfigAttribute(TypeRegistryLocal RegistryLocal, string Path)
        {
            this.RegistryLocal = RegistryLocal;
            this.Path = Path;
        }
    };

    /// <summary>
    /// Informa que a propriedade será gravada no arquivo externo
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public sealed class ExternFileConfigAttribute : System.Attribute
    {
        /// <summary>
        /// Texto do arquivo de serialização base
        /// Caso não seja específicado, será utilizado a variável da classe SettingsGameConstants
        /// </summary>
        public string ExternFileBaseSerialization { get; set; }

        /// <summary>
        /// Local onde será salvo no arquivo externo
        /// Caso não seja específicado, será utilizado a variável da classe SettingsGameConstants
        /// </summary>
        public string Path { get; set; }
    }

    /// <summary>
    /// Informa que a propriedade será gravada nos parâmetros do Jogo
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public sealed class ParamsConfigAttribute : System.Attribute { };
}
