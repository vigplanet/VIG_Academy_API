# Introduction

GrapeCity ActiveReports is a unique collection of developer reporting tools that help consume, process, and visualize data in the form of compelling and easy-to-understand reports.

GrapeCity ActiveReports provides a lot of features for developers and end-users, like:
* VisualStudio integration support.
* PaaS support (like Azure Linux App Service).
* Different possibilities to pivot and aggregate data.
* Rich data visualization.
* Popular export formats (like PDF/Excel/Word).
* And a lot more (https://www.grapecity.com/activereportsnet).

# Concept

This package includes the .NET and .NET Core assemblies required to export report to WYSIWYG PDF format.

It provides different features, like export to different PDF versions, support of encryption, support for ZUGFeRD attachments and metadata, good accessibility, AcroForms (professional license required), and others.

Please check the samples how to export:
* [Page/RDL reports](https://github.com/activereports/Samples16/tree/main/API/PageAndRDL/Export).
* [Section reports](https://github.com/activereports/Samples16/tree/main/API/Section/Export).

## Note

AcroForms are not supported for Section reports with [GDI](https://www.grapecity.com/activereportsnet/docs/v16/online/GrapeCity.ActiveReports.Document~GrapeCity.ActiveReports.Document.CompatibilityModes.html) mode.

## License

Some PDF-related features are not available with a Standard Edition license:
* Exporting with bold font emulation. It is required to obtain WYSIWYG output in case of font fallback (if cannot find an appropriate bold font).
* Exporting with [IVS](https://en.wikipedia.org/wiki/Variant_form_(Unicode)) character glyphs.
* Exporting with MS Windows [EUDC](https://docs.microsoft.com/en-us/windows/win32/intl/end-user-defined-characters) glyphs.
* Exporting with InputFields/AcroForms (a mechanism to add editable forms to the PDF file format).
* Exporting with predefined printing properties: page scaling, duplex mode, paper source by page size, print page range, number of copies.
* Signing with [Digital signature](https://en.wikipedia.org/wiki/Digital_signature) certificates.
* Adding a document [Timestamp](https://en.wikipedia.org/wiki/Timestamp).
* Exporting to [PDF/A](https://en.wikipedia.org/wiki/PDF/A) for archival preservation.
* Making the documents compliant with "Section 508" and [PDF/UA](https://en.wikipedia.org/wiki/PDF/UA).

# See also

* [GrapeCity.ActiveReports.Viewer.Win](https://www.nuget.org/packages/GrapeCity.ActiveReports.Viewer.Win/)
* [GrapeCity.ActiveReports.Viewer.Wpf](https://www.nuget.org/packages/GrapeCity.ActiveReports.Viewer.Wpf/)
* [GrapeCity.ActiveReports.Web](https://www.nuget.org/packages/GrapeCity.ActiveReports.Web/)
* [GrapeCity.ActiveReports.Aspnetcore.Viewer](https://www.nuget.org/packages/GrapeCity.ActiveReports.Aspnetcore.Viewer/)
* [GrapeCity.ActiveReports.Blazor.Viewer](https://www.nuget.org/packages/GrapeCity.ActiveReports.Blazor.Viewer/)
* [GrapeCity.ActiveReports.Design.Win](https://www.nuget.org/packages/GrapeCity.ActiveReports.Design.Win/)
* [GrapeCity.ActiveReports.Aspnetcore.Designer](https://www.nuget.org/packages/GrapeCity.ActiveReports.Aspnetcore.Designer/)
* [GrapeCity.ActiveReports.Export.Pdf](https://www.nuget.org/packages/GrapeCity.ActiveReports.Export.Pdf/)