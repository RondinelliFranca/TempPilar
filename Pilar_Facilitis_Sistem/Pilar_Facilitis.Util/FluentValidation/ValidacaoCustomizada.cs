using System;
using System.Text.RegularExpressions;

namespace Pilar_Facilitis.Util.FluentValidation
{
    public static class ValidacaoCustomizada
    {

        public static bool CampoObrigatorioPreenchido(object obj)
        {
            if (obj == null) return false;

            if (obj is string)
            {
                if (string.IsNullOrEmpty(obj.ToString())) return false;
                return true;
            }

            if (obj is Guid)
            {
                if ((Guid)obj == Guid.Empty) return false;
                return true;
            }

            if (CampoNumerico(obj))
            {
                if (obj == null || decimal.Parse(obj.ToString()) <= 0) return false;
                return true;
            }

            if (obj is DateTime)
            {
                if ((DateTime)obj == DateTime.MinValue) return false;
                return true;
            }

            if (obj.GetType().IsArray)
            {
                if (((Array)obj).Length <= 0) return false;
                return true;
            }

            return true;
        }

        public static bool NumeroPreenchido(int? numero)
        {
            if (numero == null || numero < 0) return false;
            return true;
        }

        public static bool ArrayBytesPreenchido(byte[] bytes)
        {
            if (bytes?.Length <= 0) return false;
            return true;
        }

        public static bool TamanhoValidoConteudoArquivo(byte[] conteudoByte, int tamanhoMaximo)
        {
            if (conteudoByte?.Length > tamanhoMaximo) return false;
            return true;
        }

        public static bool ApenasNumeros(string str)
        {
            if (string.IsNullOrEmpty(str)) return false;

            foreach (char c in str)
                if (c < '0' || c > '9') return false;

            return true;
        }

        public static bool DataNascimentoValida(DateTime data)
        {
            if (data > DateTime.Now.Date) return false;
            return true;
        }

        public static bool EmailValido(string email)
        {
            if (string.IsNullOrEmpty(email)) return false;

            string expressaoregular = @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*\s*$";
            if (!Regex.Match(email, expressaoregular).Success) return false;

            expressaoregular = @"^[^\s\,]+$"; //Espaços em branco
            if (!Regex.Match(email, expressaoregular).Success) return false;

            expressaoregular = @"^\S{0,64}@"; //até 64 caracteres antes do @
            if (!Regex.Match(email, expressaoregular).Success) return false;

            expressaoregular = @"@\S{0,255}$"; //até 255 caracteres depois do @
            if (!Regex.Match(email, expressaoregular).Success) return false;

            return true;
        }

        public static bool SenhaAtendeAosCriterios(string senha)
        {
            if (string.IsNullOrEmpty(senha)) return false;
            return new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!._@$%^&*-]).{8,}$").Match(senha).Success;
        }

        public static bool CNPJValido(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj)) return false;

            int[] mt1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mt2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma; int resto; string digito; string tempCNPJ;

            cnpj = Regex.Replace(cnpj, @"[^\d]", "");

            if (cnpj.Length != 14)
                return false;

            // Caso coloque todos os numeros iguais
            switch (cnpj)
            {
                case "00000000000000": return false;
                case "11111111111111": return false;
                case "22222222222222": return false;
                case "33333333333333": return false;
                case "44444444444444": return false;
                case "55555555555555": return false;
                case "66666666666666": return false;
                case "77777777777777": return false;
                case "88888888888888": return false;
                case "99999999999999": return false;
            }

            tempCNPJ = cnpj.Substring(0, 12);
            soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCNPJ[i].ToString()) * mt1[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCNPJ = tempCNPJ + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCNPJ[i].ToString()) * mt2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }

        public static bool CPFValido(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf)) return false;

            int d1, d2, soma = 0;
            string digitado = "", calculado = "";

            // Pesos para calcular o primeiro digito
            int[] peso1 = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            // Pesos para calcular o segundo digito
            int[] peso2 = new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] n = new int[11];

            cpf = Regex.Replace(cpf, @"[^\d]", "");

            // Se o tamanho for < 11 entao retorna como inválido
            if (cpf.Length != 11)
                return false;

            // Caso coloque todos os numeros iguais
            switch (cpf)
            {
                case "00000000000": return false;
                case "11111111111": return false;
                case "22222222222": return false;
                case "33333333333": return false;
                case "44444444444": return false;
                case "55555555555": return false;
                case "66666666666": return false;
                case "77777777777": return false;
                case "88888888888": return false;
                case "99999999999": return false;
            }

            try
            {
                // Quebra cada digito do CPF
                n[0] = Convert.ToInt32(cpf.Substring(0, 1));
                n[1] = Convert.ToInt32(cpf.Substring(1, 1));
                n[2] = Convert.ToInt32(cpf.Substring(2, 1));
                n[3] = Convert.ToInt32(cpf.Substring(3, 1));
                n[4] = Convert.ToInt32(cpf.Substring(4, 1));
                n[5] = Convert.ToInt32(cpf.Substring(5, 1));
                n[6] = Convert.ToInt32(cpf.Substring(6, 1));
                n[7] = Convert.ToInt32(cpf.Substring(7, 1));
                n[8] = Convert.ToInt32(cpf.Substring(8, 1));
                n[9] = Convert.ToInt32(cpf.Substring(9, 1));
                n[10] = Convert.ToInt32(cpf.Substring(10, 1));
            }
            catch
            {
                return false;
            }

            // Calcula cada digito com seu respectivo peso
            for (int i = 0; i <= peso1.GetUpperBound(0); i++)
                soma += (peso1[i] * Convert.ToInt32(n[i]));

            // Pega o resto da divisao
            int resto = soma % 11;

            if (resto == 1 || resto == 0) d1 = 0;
            else d1 = 11 - resto;

            soma = 0;

            // Calcula cada digito com seu respectivo peso
            for (int i = 0; i <= peso2.GetUpperBound(0); i++)
                soma += (peso2[i] * Convert.ToInt32(n[i]));

            // Pega o resto da divisao
            resto = soma % 11;
            if (resto == 1 || resto == 0) d2 = 0;
            else d2 = 11 - resto;

            calculado = d1.ToString() + d2.ToString();
            digitado = n[9].ToString() + n[10].ToString();

            // Se os ultimos dois digitos calculados bater com 
            // os dois ultimos digitos do cpf entao é válido
            if (calculado == digitado) return true;
            else return false;
        }


        public static bool UsuarioAtendeAosCriterios(string usuario)
        {
            if (string.IsNullOrEmpty(usuario)) return false;
            return new Regex("^(?![_])(?!.*[_]{2})[a-zA-Z0-9_]+(?<![_])$").Match(usuario).Success;
        }

        public static bool CampoNumerico(this object obj)
        {
            switch (Type.GetTypeCode(obj.GetType()))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }
    }
}