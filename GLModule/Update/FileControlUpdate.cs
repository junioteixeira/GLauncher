using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GLModule.Update
{
    public class FileControlUpdate
    {
        public string Name { get; set; }
        public string Hash { get; set; }
        public TypeFileValidation FileValidation { get; set; }

        /// <summary>
        /// Controle para arquivo de update
        /// </summary>
        /// <param name="Name">Nome</param>
        /// <param name="Hash">Hash</param>
        /// <param name="FileValidation">Tipo de validação do arquivo para update</param>
        public FileControlUpdate(string Name, string Hash, TypeFileValidation FileValidation)
        {
            this.Name = Name;
            this.Hash = Hash;
            this.FileValidation = FileValidation;
        }
    }
}
