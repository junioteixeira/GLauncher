using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace GLModule.SettingsGame
{
    /// <summary>
    /// Informa que certa propriedade não é uma configuração, ou seja, será ignorada pelo código
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public sealed class NonConfigAttribute : System.Attribute { };

    /// <summary>
    /// Informa que a propriedade será gravada no registro
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public sealed class RegisterConfigAttribute : System.Attribute { };

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
        /// 
        /// </summary>
        public string Path { get; set; }
    }

    /// <summary>
    /// Informa que a propriedade será gravada nos parâmetros do Jogo
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public sealed class ParamsConfigAttribute : System.Attribute { };
}
