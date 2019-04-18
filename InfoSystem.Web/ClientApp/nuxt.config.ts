import VuetifyLoaderPlugin from 'vuetify-loader/lib/plugin'

export default {
  mode: 'spa',
  /*
   ** Global CSS
   */
  css: ['~/assets/style/app.styl'],

  /*
   ** Plugins to load before mounting the App
   */
  plugins: ['~/plugins/vuetify'],

  modules: ['@nuxtjs/axios'],
  axios: {},
  /**
   * Build configuration
   */
  build: {
    transpile: ['vuetify/lib'],
    typescript: {
      typeCheck: false
    },
    plugins: [new VuetifyLoaderPlugin()],
    loaders: {
      stylus: {
        import: ['~assets/style/variables.styl']
      }
    }
  }
}
