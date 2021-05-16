// Copyright (c) .NET Foundation and contributors. All rights reserved. Licensed under the Microsoft Reciprocal License. See LICENSE.TXT file in the project root for full license information.

namespace WixBuildTools.XsdToMarkdown
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Updates Xsd objects so that parents and children across xsds are reflected everywhere.
    /// </summary>
    public static class XsdFinalizer
    {
        public static IEnumerable<Xsd> Finalize(IEnumerable<Xsd> xsds)
        {
            var xsdByNamespace = xsds.ToDictionary(x => x.TargetNamespace);

            foreach (var xsd in xsdByNamespace.Values)
            {
                foreach (var attr in xsd.RootAttributes?.Values)
                {
                    foreach (var parent in attr.Parents)
                    {
                        if (xsdByNamespace.TryGetValue(parent.Namespace, out var targetXsd)
                            && targetXsd.Elements.TryGetValue(parent.Name, out var targetElement))
                        {
                            targetElement.Attributes[parent.Name] = attr;
                        }
                    }
                }

                foreach (var element in xsd.Elements.Values)
                {
                    foreach (var parent in element.Parents.Values)
                    {
                        if (xsdByNamespace.TryGetValue(parent.Namespace, out var targetXsd)
                            && targetXsd.Elements.TryGetValue(parent.Name, out var targetElement))
                        {
                            // TODO: Stretch: dig up cardinality and documentation. v3 doc doesn't but maybe we can do better, eh?
                            targetElement.Children[element.Name] = new Child(element.Namespace, element.Name, String.Empty, String.Empty);
                        }
                    }

                    // add this element as a parent to each child (e.g., Product child-> Component <-parent Product)
                    foreach (var child in element.Children.Values)
                    {
                        if (xsdByNamespace.TryGetValue(child.Namespace, out var targetXsd)
                            && targetXsd.Elements.TryGetValue(child.Name, out var targetElement))
                        {
                            targetElement.Parents[element.Name] = new Parent(element.Namespace, element.Name);
                        }
                    }
                }
            }

            return xsdByNamespace.Values;
        }
    }
}
