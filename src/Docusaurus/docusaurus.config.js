// @ts-check
// Note: type annotations allow type checking and IDEs autocompletion

const lightCodeTheme = require('prism-react-renderer/themes/github');
const darkCodeTheme = require('prism-react-renderer/themes/dracula');

/** @type {import('@docusaurus/types').Config} */
const config = {
  title: 'WiX Toolset',
  tagline: 'The most powerful set of tools available to create your Windows installation experience.',
  url: 'https://wixtoolset.org/',
  baseUrl: '/',
  onBrokenLinks: 'warn',
  onBrokenMarkdownLinks: 'warn',
  favicon: 'favicon.ico',
  trailingSlash: true,

  organizationName: 'wixtoolset',
  projectName: 'web',

  i18n: {
    defaultLocale: 'en',
    locales: ['en'],
  },

  presets: [
    [
      'classic',
      /** @type {import('@docusaurus/preset-classic').Options} */
      ({
        docs: {
          sidebarPath: require.resolve('./sidebars.js'),
          editUrl: 'https://github.com/wixtoolset/web/tree/master/src/Docusaurus/',
          lastVersion: 'current',
          versions: {
            current: {
              label: "v4.0",
              banner: 'none'
            },
            'v3': {
              label: "v3",
              path: 'v3',
              banner: 'unmaintained',
              className: 'v3-doc'
            }
          }
        },
        blog: {
          blogTitle: 'WiX Toolset News',
          blogDescription: 'Updates about the WiX Toolset',
          blogSidebarTitle: 'Recent news',
          path: 'news',
          routeBasePath: '/news',
          showReadingTime: false
        },
        theme: {
          customCss: require.resolve('./src/css/custom.css'),
        },
      }),
    ],
  ],

  themeConfig:
    /** @type {import('@docusaurus/preset-classic').ThemeConfig} */
    ({
      navbar: {
        title: 'WiX Toolset',
        logo: {
          alt: 'Logo',
          src: 'img/logo-white-hollow-xs.png',
          srcDark: 'img/logo-black-hollow-xs.png',
        },
        items: [
          { to: '/news', label: 'News', position: 'right' },
          { type: 'doc', docId: 'intro', label: 'Docs', position: 'right' },
          { href: 'https://github.com/wixtoolset/', label: 'GitHub', position: 'right' },
          { href: 'https://www.firegiant.com/services/', label: 'Enterprise', position: 'right'},
        ],
      },
      footer: {
        style: 'dark',
        links: [
          {
            items: [
              {
                html: `
                  <p class="footer_label">Support provided by</p>
                  <a href="https://www.firegiant.com/">
                    <img src="/img/firegiant.png" alt="FireGiant" />
                  </a>

                `
              },
              {
                html: `
                  <p class="footer_label">Member of the</p>
                  <a href="https://dotnetfoundation.org/">
                    <img src="/img/dotnetfoundation.png" alt=".NET Foundation" />
                  </a>
                `
              }
            ]
          },
          {
            title: 'Community',
            items: [
              { href: 'https://stackoverflow.com/questions/tagged/wix', label: 'Stack Overflow' },
              { href: 'https://www.youtube.com/wixtoolset', label: 'YouTube' },
              { href: 'https://twitter.com/wixtoolset', label: 'Twitter' },
            ],
          },
          {
            title: 'More',
            items: [
              { to: '/news', label: 'News' },
              { href: 'https://www.firegiant.com/services/', label: 'Enterprise' },
              { href: 'https://github.com/wixtoolset/web', label: 'GitHub' },
            ],
          },
        ],
        copyright: `Copyright © ${new Date().getFullYear()} .NET Foundation and contributors.`,
      },
      prism: {
        theme: lightCodeTheme,
        darkTheme: darkCodeTheme,
        additionalLanguages: ['csharp'],
      },
    }),

  scripts: [
    {
      'src': "https://plausible.io/js/script.js",
      'defer': true,
      'data-domain': "wixtoolset.org"
    }
  ]
};

module.exports = config;
