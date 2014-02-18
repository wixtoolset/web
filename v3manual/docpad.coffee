# DocPad Configuration File
# http://docpad.org/docs/config

# Define the DocPad Configuration
docpadConfig = {
  packagePath: '../package.json'

  pluginsPaths: [ '../node_modules' ]

  checkVersion: false

  reportStatistics: false

  templateData:
    site:
        url: "http://wixtoolset.org"

  enabledPlugins:
    cleanurls: false  # manual not designed to have clean URLs.
    sitemap: false    # currently broken     
}

# Export the DocPad Configuration
module.exports = docpadConfig
