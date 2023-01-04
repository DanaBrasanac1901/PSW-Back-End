using HospitalAPI.Controllers;
using HospitalLibrary.Core.EmailSender;
using HospitalLibrary.Core.Tender;
using HospitalLibrary.Core.TenderOffer;
using IntegrationAPI;
using IntegrationLibrary.BloodBank;
using IntegrationLibrary.News;
using IntegrationTests.Integration;
using IntegrationTests.Setup;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class TenderTests : BaseIntegrationTest
    {
        public TenderTests(TestDatabaseFactory<Startup> factory) : base(factory) { }
        [Fact]
        public void Should_send_email_to_winner()
        {
            using var scope = Factory.Services.CreateScope();
            var mockEmail = new Mock<IEmailSendService>();
            var mockTender = new Mock<ITenderService>();
            var mockTenderOffer = new Mock<ITenderOfferService>();
            mockEmail.Setup(p => p.SendEmail(It.IsAny<Message>())).Returns(true);
            var tot = new TenderOffersController(mockTenderOffer.Object,Factory.Services.CreateScope().ServiceProvider.GetRequiredService<IBloodBankService>(), mockEmail.Object, mockTender.Object);
            tot.NotifyWinner(new TenderOffer(1, 2.2, new Guid("a60460fe-0d33-478d-93b3-45d424079e66")));
            mockEmail.Verify(p => p.SendEmail(It.IsAny<Message>()), Times.Once);
        }
        [Fact]
        public void Should_send_email_to_losers()
        {
            var mockEmail = new Mock<IEmailSendService>();
            var mockTender = new Mock<ITenderService>();
            var mockTenderOffer = new Mock<ITenderOfferService>();
            var mockBloodBank = new Mock<IBloodBankService>();
            mockEmail.Setup(p => p.SendEmail(It.IsAny<Message>())).Returns(true);
            var tot = new TenderOffersController(mockTenderOffer.Object, mockBloodBank.Object, mockEmail.Object, mockTender.Object);
            tot.NotifyLosers("",new DateTime());
            mockEmail.Verify(p => p.SendEmail(It.IsAny<Message>()), Times.AtLeastOnce);
        }
    }
}
