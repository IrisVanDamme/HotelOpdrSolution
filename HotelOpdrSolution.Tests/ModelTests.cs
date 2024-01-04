using HotelOpdrSolution.BL.Model;
using Microsoft.VisualBasic;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOpdrSolution.Tests
{
    public class ModelTests
    {
        // Member class
        [Theory]
        [InlineData(50)]
        [InlineData(500)]
        public void Member_NameLengthValid_Valid(int length)
        {
            Member member = new Member(new string('a', length), DateOnly.Parse("01-02-2000"));
            Assert.NotNull(member);
        }

        [Theory]
        [InlineData(501)]
        [InlineData(600)]
        public void Member_NameLengthTooBig_ThrowArgumentException(int length)
        {
            Assert.Throws<ArgumentException>(() => new Member(new string('a', length), DateOnly.Parse("01-02-2000")));
        }

        [Fact]
        public void Member_EmptyName_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Member(string.Empty, DateOnly.Parse("01-02-2000")));
        }
        [Fact]
        public void Member_NameNull_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Member(null, DateOnly.Parse("01-02-2000")));
        }

        // ContactInfo class
        [Fact]
        public void ContactInfo_EmailWithAt_Valid()
        {
            // geen mockobject gebruiken voor Address, want in Address moet niets getest worden
            ContactInfo ci = new ContactInfo("iris@hotmail.com", "0487878787", new Address("Gentstraat", "2A", "9000", "Gent"));
            Assert.NotNull(ci);
        }

        [Fact]
        public void ContactInfo_EmailWithoutAt_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ContactInfo("irishotmail.com", "0487878787", new Address("Gentstraat", "2A", "9000", "Gent")));
        }

        [Fact]
        public void ContactInfo_EmptyPhoneNumber_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ContactInfo("iris@hotmail.com", string.Empty, new Address("Gentstraat", "2A", "9000", "Gent")));
        }
        [Fact]
        public void ContactInfo_PhoneNumberNull_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ContactInfo("iris@hotmail.com", null, new Address("Gentstraat", "2A", "9000", "Gent")));
        }
    }
}
