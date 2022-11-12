import React from 'react';
import clsx from 'clsx';
import Link from '@docusaurus/Link';
import styles from './styles.module.css';

import BookSvg from '@site/static/img/open-book.svg';
import DownloadSvg from '@site/static/img/icon-download.svg';
import BugSvg from '@site/static/img/bug-search.svg';

const FeatureList = [
  {
    title: 'Documentation',
    Svg: BookSvg,
    description: (
      <>
        There are lots of ways to learn about the WiX toolset.
      </>
    ),
    linkText: 'Read more',
    href: '/docs/intro'
  },
  {
    title: 'Download',
    Svg: DownloadSvg,
    description: (
      <>
        You can download the WiX toolset for free.
      </>
    ),
    linkText: 'Latest releases',
    href: '/docs/wix3/'
  },
  {
    title: 'Bugs',
    Svg: BugSvg,
    description: (
      <>
        If you find a bug, let us know so we can fix it.
      </>
    ),
    linkText: 'File a bug',
    href: '/docs/gethelp#bugs'
  },
];

function Feature({Svg, title, description, linkText, href}) {
  return (
    <div className='col col--4'>
      <div className="text--center">
        <Link to={href}>
          <Svg className={styles.featureSvg} role="img" />
        </Link>
      </div>
      <div className="text--center padding-horiz--md">
        <h3>{title}</h3>
        <p>{description}</p>
        <Link
            className="button button--primary button--lg"
            to={ href }>
            { linkText }
        </Link>
      </div>
    </div>
  );
}

export default function HomepageFeatures() {
  return (
    <section className={styles.features}>
      <div className="container">
        <div className="row">
          {FeatureList.map((props, idx) => (
            <Feature key={idx} {...props} />
          ))}
        </div>
      </div>
    </section>
  );
}
