' Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

Imports System.Threading
Imports Microsoft.CodeAnalysis.VisualBasic.Syntax
Imports Microsoft.CodeAnalysis.Editor.Implementation.Outlining

Namespace Microsoft.CodeAnalysis.Editor.VisualBasic.Outlining
    Class CompilationUnitOutliner
        Inherits AbstractSyntaxNodeOutliner(Of CompilationUnitSyntax)

        Protected Overrides Sub CollectOutliningSpans(compilationUnit As CompilationUnitSyntax, spans As List(Of OutliningSpan), cancellationToken As CancellationToken)
            Dim regions As New List(Of OutliningSpan)

            VisualBasicOutliningHelpers.CollectCommentsRegions(compilationUnit, spans)
            spans.Add(VisualBasicOutliningHelpers.CreateRegion(compilationUnit.Imports, "Imports ...", autoCollapse:=True))
            VisualBasicOutliningHelpers.CollectCommentsRegions(compilationUnit.EndOfFileToken.LeadingTrivia, spans)
        End Sub

        Protected Overrides Function SupportedInWorkspaceKind(kind As String) As Boolean
            Return True
        End Function
    End Class
End Namespace
