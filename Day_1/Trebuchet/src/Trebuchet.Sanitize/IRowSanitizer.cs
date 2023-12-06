namespace Trebuchet.Sanitize;
public interface IRowSanitizer
{
    SanitizedRow SanitizeRow(string row);
}
