using AutoFixture.AutoNSubstitute;
using studentdetailAPIdemo.Models;
using studentdetailAPIdemo.Repositories;
using System;
using System.Collections.Generic;
using Xunit;
using AutoFixture;
using studentdetailAPIdemo.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NSubstitute;

namespace StudentAPIDemoTest
{
    public class UnitTest1
    {
       
        [Fact]
        public void GetStudentDetailsById_ShouldNotReturnNull()
        {
            var fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
            var repo = fixture.Freeze<IStudentRepository>();
            fixture.Inject(repo);
            fixture.Customize<BindingInfo>(a=>a.OmitAutoProperties());
            var sut = fixture.Build<StudentsController>().OmitAutoProperties().Create();
            var result = sut.Get();
            repo.Received(1).GetStudentDetails();
            
        }
        [Fact]
        public void GetProductDetailsById_ShouldGetStarted()
        {
            var fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
            var repo = fixture.Freeze<IProductsRepository>();
            fixture.Inject(repo);
            fixture.Customize<BindingInfo>(a => a.OmitAutoProperties());
            var sut = fixture.Build<ProductsController>().OmitAutoProperties().Create();
            var result = sut.Get();
            repo.Received(1).Get();
        }
        
      
    }
}
