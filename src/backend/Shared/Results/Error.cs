namespace Shared.Results
{
    public record Error(string Code, string Description, ErrorTypes Type)
    {
        public static readonly Error None = new(string.Empty, string.Empty, ErrorTypes.Failure);
        public static readonly Error NullValue = new("Error.NullValue", "Null value was provided.", ErrorTypes.Validation);

        public static Error NotFound(string code, string description) => new(code, description, ErrorTypes.NotFound);
        public static Error Validation(string code, string description) => new(code, description, ErrorTypes.Validation);
        public static Error Conflict(string code, string description) => new(code, description, ErrorTypes.Conflict);
    }
}
