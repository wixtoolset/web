# DocPad Configuration File
# http://docpad.org/docs/config

# Define the DocPad Configuration
docpadConfig = {
  packagePath: '../package.json'

  pluginsPaths: [ '../node_modules' ]

  checkVersion: false

  reportStatistics: false

  collections:
    news: ->
      @getCollection('documents').findAllLive({relativeDirPath: 'news'}, [{date:-1}])

    wips: ->
      @getCollection('documents').findAllLive({relativeDirPath: 'development\\wips'}, [{wip: 1}]).on "add", (model) ->
        model.setMetaDefaults({layout:'wip', under:'Development'})

    releases: ->
      @getCollection('documents').findAllLive({relativeDirPath: 'releases'}, [{date:-1}]).on "add", (model) ->
        model.setMetaDefaults({layout:'release', subtitle:'WiX Toolset Release', under:'Releases'})

  templateData:
    site:
      url: "http://wixtoolset.org"

    getReleaseInfo: (doc) ->
      doc ?= @document
      @getFile({ $and: [{basename: doc.basename}, {extension: 'json'}]})

    prettyFormatDate: (date) ->
      months = [ "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" ]
      days = [ "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" ]
      days[date.getDay()] + ', ' + months[date.getMonth()] + ' ' + ('0' + date.getDate()).slice(-2) + ', ' + date.getFullYear()

  enabledPlugins:
    sitemap: false # currently broken
}

# Export the DocPad Configuration
module.exports = docpadConfig
