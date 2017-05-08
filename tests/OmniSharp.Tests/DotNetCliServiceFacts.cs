﻿using OmniSharp.Services;
using TestUtility;
using Xunit;
using Xunit.Abstractions;

namespace OmniSharp.Tests
{
    public class DotNetCliServiceFacts : AbstractTestFixture
    {
        public DotNetCliServiceFacts(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        public void LegacyGetVersion()
        {
            using (var host = CreateOmniSharpHost(useLegacyDotNetCli: true))
            {
                var dotNetCli = host.GetExport<DotNetCliService>();

                var version = dotNetCli.GetVersion();

                Assert.Equal(1, version.Major);
                Assert.Equal(0, version.Minor);
                Assert.Equal(0, version.Patch);
                Assert.Equal("preview2-1-003177", version.Release);
            }
        }

        [Fact]
        public void LegacyGetInfo()
        {
            using (var host = CreateOmniSharpHost(useLegacyDotNetCli: true))
            {
                var dotNetCli = host.GetExport<DotNetCliService>();

                var info = dotNetCli.GetInfo();

                Assert.Equal(1, info.Version.Major);
                Assert.Equal(0, info.Version.Minor);
                Assert.Equal(0, info.Version.Patch);
                Assert.Equal("preview2-1-003177", info.Version.Release);
            }
        }

        [Fact]
        public void GetVersion()
        {
            using (var host = CreateOmniSharpHost(useLegacyDotNetCli: false))
            {
                var dotNetCli = host.GetExport<DotNetCliService>();

                var version = dotNetCli.GetVersion();

                Assert.Equal(1, version.Major);
                Assert.Equal(0, version.Minor);
                Assert.Equal(1, version.Patch);
                Assert.Equal("", version.Release);
            }
        }

        [Fact]
        public void GetInfo()
        {
            using (var host = CreateOmniSharpHost(useLegacyDotNetCli: false))
            {
                var dotNetCli = host.GetExport<DotNetCliService>();

                var info = dotNetCli.GetInfo();

                Assert.Equal(1, info.Version.Major);
                Assert.Equal(0, info.Version.Minor);
                Assert.Equal(1, info.Version.Patch);
                Assert.Equal("", info.Version.Release);
            }
        }
    }
}
