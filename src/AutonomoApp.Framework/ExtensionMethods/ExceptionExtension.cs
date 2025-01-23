using System.Reflection;
using System.Text;

namespace AutonomoApp.Framework.ExtensionMethods;

public static class ExceptionExtension
{
    public static void CustomTrace(this Exception e, Action<StringBuilder> action)
    {
        if (e == null) return;

        StringBuilder sb = new StringBuilder();

        sb.AppendLine(e.Message);

        while ((e = e.InnerException) != null)
        {
            sb.AppendLine(e.Message);
        }

        action(sb);
    }

    public static string CustomTraceMessage(this Exception e)
    {
        if (e == null)
            return "";

        StringBuilder sb = new StringBuilder();

        sb.AppendLine(GetExceptionMessage(e));

        while ((e = e.InnerException) != null)
        {
            sb.AppendLine(GetExceptionMessage(e));
        }

        return sb.ToString();
    }

    private static string GetExceptionMessage(Exception e, bool getAllMessages = false)
    {
        if (e is ReflectionTypeLoadException)
        {
            return GetTypeLoadExceptionMessage(e as ReflectionTypeLoadException);
        }

        if (e is TypeLoadException)
        {
            return GetTypeLoadExceptionMessage(e as TypeLoadException);
        }

        return getAllMessages ? e.GetAllMessages() : e.Message;
    }

    private static string GetTypeLoadExceptionMessage(ReflectionTypeLoadException reflectionTypeLoadException)
    {
        return "Message: {1} -- ReflectionLoadException Types: {0}"
            .Fmt(
                reflectionTypeLoadException
                    .LoaderExceptions
                    .Select(x => x.Message)
                        .Aggregate((a, b) => a + Environment.NewLine + b),
                reflectionTypeLoadException.Message
             );
    }

    private static string GetTypeLoadExceptionMessage(TypeLoadException typeLoadException)
    {
        return "LoadException Type: {0} Message: {1}".Fmt(typeLoadException.TypeName, typeLoadException.Message);
    }

    public static string GetAllMessages(this Exception exception)
    {
        var messages = exception
                .FromHierarchy(ex => ex.InnerException)
                .Select(ex =>
                {
                    if (ex is AggregateException)
                    {
                        var mensagens = new List<string>();

                        (ex as AggregateException).Handle(aex =>
                        {
                            mensagens.Add(exception.Message);
                            return true;
                        });

                        return string.Join("; ", mensagens);
                    }

                    return ex.Message;
                });



        return string.Join(Environment.NewLine, messages);
    }

}
