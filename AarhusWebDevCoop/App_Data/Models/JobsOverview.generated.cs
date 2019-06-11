//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder v3.0.10.102
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.ModelsBuilder;
using Umbraco.ModelsBuilder.Umbraco;

namespace Umbraco.Web.PublishedContentModels
{
	/// <summary>Jobs Overview</summary>
	[PublishedContentModel("jobsOverview")]
	public partial class JobsOverview : Master
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "jobsOverview";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public JobsOverview(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<JobsOverview, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Jobs content
		///</summary>
		[ImplementPropertyType("jobsContent")]
		public IHtmlString JobsContent
		{
			get { return this.GetPropertyValue<IHtmlString>("jobsContent"); }
		}

		///<summary>
		/// Jobs title
		///</summary>
		[ImplementPropertyType("jobsTitle")]
		public string JobsTitle
		{
			get { return this.GetPropertyValue<string>("jobsTitle"); }
		}
	}
}
