using System;
using System.Collections.Generic;
using System.Linq;

namespace Questao04
{
    public static class MetodoExtensao
    {
        public static List<T> RemoveRepetidos<T>(this List<T> lista)
        {
            return lista.Distinct().ToList();
        }
    }
}
