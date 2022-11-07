import React from 'react';
import Link from '@docusaurus/Link';
import useDocusaurusContext from '@docusaurus/useDocusaurusContext';
import Layout from '@theme/Layout';

import HomepageHeader from '@site/src/components/HomepageHeader';
import HomepageFeatures from '@site/src/components/HomepageFeatures';

import styles from './index.module.css';

// HACK: This reaches into the depths of Docusaurus and may break in future updates.
const recentPosts = require("../../.docusaurus/docusaurus-plugin-content-blog/default/blog-post-list-prop-default.json");

function MoreAbout() {
  return (
    <div className="col col--4">
      <h3>About the WiX toolset</h3>
      <p>The WiX toolset lets developers create installers for Windows Installer, the Windows installation engine.</p>
      <ul>
        <li><p>The core of WiX is a set of build tools that build Windows Installer packages using the same build concepts as the rest of your product: source code is compiled and then linked to create executables; in this case .exe setup bundles, .msi installation packages, .msm merge modules, and .msp patches. The WiX command-line build tools work with any automated build system. Also, MSBuild is supported from the command line, Visual Studio, and Team Build.</p></li>
        <li><p>WiX includes several extensions that offer functionality beyond that of Windows Installer. For example, WiX can install IIS web sites, create SQL Server databases, and register exceptions in the Windows Firewall, among others.</p></li>
        <li><p>With Burn, the WiX bootstrapper, you can create setup bundles that install prerequisites like the .NET Framework and other runtimes along with your own product. Burn lets you download packages or combine them into a single downloadable .exe.</p></li>
        <li><p>The WiX SDK includes managed and native libraries that make it easier to write code that works with Windows Installer, including custom actions in both C# and C++.</p></li>
      </ul>
    </div>
  );
}

function RecentNews() {
  return (
    <div className="col col--4">
      <h3>Recent news</h3>
      <p>The following blogs may have additional news about the progress of the WiX toolset:</p>
      <ul>
          {recentPosts.items.slice(0, 5).map((item, index) => (
            <h4 key={index}>
              <Link to={item.permalink}>{item.title}</Link>
            </h4>
          ))}
        </ul>
    </div>
  );
}

function OtherNewsSources() {
  return (
    <div className="col col--4">
      <h3>Other sources of news</h3>
      <p>The following blogs may have additional news about the progress of the WiX toolset:</p>
      <ul>
        <li><Link to="https://robmensching.com/blog/">Rob Mensching</Link></li>
        <li><Link to="https://www.joyofsetup.com/">Bob Arnson</Link></li>
        <li><Link to="https://www.firegiant.com/blog/">FireGiant's Setup Matters</Link></li>
      </ul>
    </div>
  );
}

export default function Home() {
  const {siteConfig} = useDocusaurusContext();
  return (
    <Layout
      description={siteConfig.tagline}>
      <HomepageHeader />
      <main>
        <HomepageFeatures />

        <section className={styles.features}>
          <div className="container">
            <div className="row">
              <MoreAbout />
              <RecentNews />
              <OtherNewsSources />
            </div>
          </div>
        </section>
      </main>
    </Layout>
  );
}
