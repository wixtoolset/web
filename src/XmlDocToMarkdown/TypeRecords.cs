using System;
using System.Collections.Generic;

namespace WixBuildTools.XmlDocToMarkdown;

public record Parameter(string Name, string Type, string Summary);

public record ThrownException(string Type, string Summary);

public record Member(string Keywords, string Namespace, string TypeName, string Name, string Summary, string Remarks, IEnumerable<string> SeeAlsos);

public record Method(string Keywords, string Namespace, string TypeName, string Name, string Signature, string ReturnType, string Summary, string Remarks, IEnumerable<string> SeeAlsos, string Returns, IEnumerable<Parameter> Parameters, IEnumerable<ThrownException> Exceptions)
    : Member(Keywords, Namespace, TypeName, Name, Summary, Remarks, SeeAlsos);

public record Constructor(string Keywords, string Namespace, string Name, string Signature, string Summary, string Remarks, IEnumerable<string> SeeAlsos, string Returns, IEnumerable<Parameter> Parameters, IEnumerable<ThrownException> Exceptions)
    : Method(Keywords, Namespace, Name, Name, Signature, String.Empty, Summary, Remarks, SeeAlsos, Returns, Parameters, Exceptions);

public record Property(string Keywords, string Namespace, string TypeName, string Name, string Type, string Summary, string Remarks, IEnumerable<string> SeeAlsos, IEnumerable<Parameter> Parameters, IEnumerable<ThrownException> Exceptions, bool CanRead, bool CanWrite)
    : Member(Keywords, Namespace, TypeName, Name, Summary, Remarks, SeeAlsos);

public record Field(string Keywords, string Namespace, string TypeName, string Name, string Type, string Summary, string Remarks, IEnumerable<string> SeeAlsos)
    : Member(Keywords, Namespace, TypeName, Name, Summary, Remarks, SeeAlsos);

public record Event(string Keywords, string Namespace, string TypeName, string Name, string Type, string Summary, string Remarks, IEnumerable<string> SeeAlsos)
    : Member(Keywords, Namespace, TypeName, Name, Summary, Remarks, SeeAlsos);

public enum TypeFlavor
{
    Unknown,
    Class,
    Struct,
    Interface,
    Enumeration,
    Delegate,
}

public record DocType(TypeFlavor TypeFlavor, string Namespace, string Name, string Summary, string Remarks, IEnumerable<string> SeeAlsos, ICollection<Member> Members, string AssemblyFileName, string AssemblyVersion);
