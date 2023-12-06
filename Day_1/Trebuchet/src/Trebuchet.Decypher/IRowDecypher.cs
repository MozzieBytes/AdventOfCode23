using Trebuchet.Sanitize;

namespace Trebuchet.Decypher;
internal interface IRowDecypher
{
    DecypheredRow DecypherRow(SanitizedRow row);
}
