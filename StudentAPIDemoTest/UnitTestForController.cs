using AutoFixture;
using AutoFixture.AutoNSubstitute;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NSubstitute;
using studentdetailAPIdemo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StudentAPIDemoTest
{
    
    public class UnitTestForController
    {
        [Fact]
        public void ProductRepository_ShouldGetActivated()
        {

            var fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
            var repo = fixture.Freeze<IProductsRepository>();
            fixture.Inject(repo);
            fixture.Customize<BindingInfo>(a => a.OmitAutoProperties());
            var sut = fixture.Build<ProductRepository>().OmitAutoProperties().Create();
            var result = sut.Get();
            repo.Received(1).Get();
           
            
           
        }
    }
}
