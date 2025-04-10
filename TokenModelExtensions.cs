using csly.cli.model.lexer;
using sly.lexer;

namespace CslyViz;

public static  class TokenModelExtensions
{
    public static string ToCliSource(this TokenModel tokenModel)
    {
        if (tokenModel.Type == GenericToken.Int)
        {
            return $"[Int] {tokenModel.Name};";
        }

        if (tokenModel.Type == GenericToken.Double)
        {
            if (tokenModel.Args != null && tokenModel.Args.Length == 1 && !string.IsNullOrEmpty(tokenModel.Args[0]))
            {
                return $@"[Double] {tokenModel.Name} : ""{tokenModel.Args[0]}"";";
            }
            return $@"[Double] {tokenModel.Name};";
        }

        if (tokenModel.Type == GenericToken.String)
        {
            if (tokenModel.Args != null && tokenModel.Args.Length == 2)
            {
                return $@"[String] {tokenModel.Name} : ""{tokenModel.Args[0]}"" ""{tokenModel.Args[1]}"" ;";
            }
            return $@"[String] {tokenModel.Name};";
        }
        
        if (tokenModel.Type == GenericToken.Char)
        {
            if (tokenModel.Args != null && tokenModel.Args.Length == 2)
            {
                return $@"[Char] {tokenModel.Name} : ""{tokenModel.Args[0]}"" ""{tokenModel.Args[1]}"" ;";
            }
            return $@"[Char] {tokenModel.Name};";
        }
        
        if (tokenModel.Type == GenericToken.Identifier && tokenModel.IdentifierType == IdentifierType.Custom)
        {
            if (tokenModel.Args != null && tokenModel.Args.Length == 2)
            {
                return $@"[CustomId] {tokenModel.Name} : ""{tokenModel.Args[0]}"" ""{tokenModel.Args[1]}"" ;";
            }
            return $@"[CustomId] {tokenModel.Name};";
        }
        
        if (tokenModel.Type == GenericToken.Identifier && tokenModel.IdentifierType == IdentifierType.Alpha)
        {
            return $@"[AlphaId] {tokenModel.Name};";
        }
        
        if (tokenModel.Type == GenericToken.Identifier && tokenModel.IdentifierType == IdentifierType.AlphaNumeric)
        {
            return $@"[AlphaNumId] {tokenModel.Name};";
        }
        
        if (tokenModel.Type == GenericToken.Identifier && tokenModel.IdentifierType == IdentifierType.AlphaNumericDash)
        {
            return $@"[AlphaNumDashId] {tokenModel.Name};";
        }

        if (tokenModel.Type == GenericToken.KeyWord && tokenModel.Args != null && tokenModel.Args.Length == 1)
        {
            return $@"[keyWord] {tokenModel.Name} : ""{tokenModel.Args[0]}"";";
        }
        
        if (tokenModel.Type == GenericToken.Date && tokenModel.Args != null && tokenModel.Args.Length == 2)
        {
            return $@"[Date] {tokenModel.Name} : {tokenModel.Args[0]} '{tokenModel.Args[1]}';";
        }
        
        if (tokenModel.Type == GenericToken.Comment && tokenModel.Args != null && tokenModel.Args.Length == 2)
        {
            return $@"[MultiLineComment] {tokenModel.Name} : ""{tokenModel.Args[0]}"" ""{tokenModel.Args[1]}"";";
        }
        
        if (tokenModel.Type == GenericToken.Comment && tokenModel.Args != null && tokenModel.Args.Length == 1)
        {
            return $@"[SingleLineComment] {tokenModel.Name} : ""{tokenModel.Args[0]}"" ;";
        }
        if (tokenModel.Type == GenericToken.SugarToken && tokenModel.Args != null && tokenModel.Args.Length == 1)
        {
            return $@"[Sugar] {tokenModel.Name} : ""{tokenModel.Args[0]}"" ;";
        }

        if (tokenModel.Type == GenericToken.Extension)
        {
            return $@"[Extension] {tokenModel.Name}
>>>
<<<";
        }
        
        if (tokenModel.Type == GenericToken.Hexa && tokenModel.Args != null && tokenModel.Args.Length == 1)
        {
            return $@"[Hexa] {tokenModel.Name} : ""{tokenModel.Args[0]}"" ;";
        }

        return "to come";
    }
}