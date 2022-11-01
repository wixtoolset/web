import React from 'react';
import Translate, {translate} from '@docusaurus/Translate';
import {PageMetadata} from '@docusaurus/theme-common';
import Layout from '@theme/Layout';
import BrowserOnly from '@docusaurus/BrowserOnly';

const OpenIssueLink = () => {
  return (
    <BrowserOnly fallback={<a href="https://github.com/wixtoolset/issues/issues/new?assignees=&labels=triage&template=page_not_found.yml&title=Page Not Found: put page url here">open an issue</a>}>
      {() => <a href={"https://github.com/wixtoolset/issues/issues/new?assignees=&labels=triage&template=page_not_found.yml&title=Page Not Found: " + encodeURIComponent(window.location.pathname + window.location.hash + window.location.search) + "&page=" + encodeURIComponent(window.location.href) + "&ref=" + encodeURIComponent(document.referrer)}>open an issue</a>}
    </BrowserOnly>
  );
};

export default function NotFound() {
  return (
    <>
      <PageMetadata
        title={translate({
          id: 'theme.NotFound.title',
          message: 'Page Not Found',
        })}
      />
      <Layout>
        <main className="container margin-vert--xl">
          <div className="row">
            <div className="col col--6 col--offset-3">
              <h1 className="hero__title">
                <Translate
                  id="theme.NotFound.title"
                  description="The title of the 404 page">
                  Page Not Found
                </Translate>
              </h1>
              <p>
                <Translate
                  id="theme.NotFound.p1"
                  description="The first paragraph of the 404 page">
                  We could not find what you were looking for.
                </Translate>
              </p>
              <p>
                Please <OpenIssueLink /> with
                this page URL and the URL of the page that sent you here. That will help us track down the missing page.
              </p>
            </div>
          </div>
        </main>
      </Layout>
    </>
  );
}
