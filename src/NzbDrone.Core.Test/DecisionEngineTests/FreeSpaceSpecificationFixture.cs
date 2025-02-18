using FluentAssertions;
using Moq;
using NUnit.Framework;
using NzbDrone.Common.Disk;
using NzbDrone.Common.Extensions;
using NzbDrone.Core.Configuration;
using NzbDrone.Core.DecisionEngine.Specifications;
using NzbDrone.Core.Movies;
using NzbDrone.Core.Parser.Model;
using NzbDrone.Core.Test.Framework;
using NzbDrone.Test.Common;

namespace NzbDrone.Core.Test.DecisionEngineTests
{
    public class FreeSpaceSpecificationFixture : CoreTest<FreeSpaceSpecification>
    {
        private RemoteMovie _remoteMovie;

        [SetUp]
        public void Setup()
        {
            _remoteMovie = new RemoteMovie() { Release = new ReleaseInfo(), Movie = new Movie { Path = @"C:\Test\Films\Movie".AsOsAgnostic() } };
        }

        private void WithMinimumFreeSpace(int size)
        {
            Mocker.GetMock<IConfigService>().SetupGet(c => c.MinimumFreeSpaceWhenImporting).Returns(size);
        }

        private void WithAvailableSpace(int size)
        {
            Mocker.GetMock<IDiskProvider>().Setup(s => s.GetAvailableSpace(It.IsAny<string>())).Returns(size.Megabytes());
        }

        private void WithSize(int size)
        {
            _remoteMovie.Release.Size = size.Megabytes();
        }

        [Test]
        public void should_return_true_when_available_space_is_more_than_size()
        {
            WithMinimumFreeSpace(0);
            WithAvailableSpace(200);
            WithSize(100);

            Subject.IsSatisfiedBy(_remoteMovie, null).Accepted.Should().BeTrue();
        }

        [Test]
        public void should_return_true_when_available_space_minus_size_is_more_than_minimum_free_space()
        {
            WithMinimumFreeSpace(50);
            WithAvailableSpace(200);
            WithSize(100);

            Subject.IsSatisfiedBy(_remoteMovie, null).Accepted.Should().BeTrue();
        }

        [Test]
        public void should_return_false_available_space_is_less_than_size()
        {
            WithMinimumFreeSpace(0);
            WithAvailableSpace(200);
            WithSize(1000);

            Subject.IsSatisfiedBy(_remoteMovie, null).Accepted.Should().BeFalse();
        }

        [Test]
        public void should_return_false_when_available_space_minus_size_is_less_than_minimum_free_space()
        {
            WithMinimumFreeSpace(150);
            WithAvailableSpace(200);
            WithSize(100);

            Subject.IsSatisfiedBy(_remoteMovie, null).Accepted.Should().BeFalse();
        }

        [Test]
        public void should_return_true_if_skip_free_space_check_is_true()
        {
            Mocker.GetMock<IConfigService>()
                .Setup(s => s.SkipFreeSpaceCheckWhenImporting)
                .Returns(true);

            WithMinimumFreeSpace(150);
            WithAvailableSpace(200);
            WithSize(100);

            Subject.IsSatisfiedBy(_remoteMovie, null).Accepted.Should().BeTrue();
        }
    }
}
