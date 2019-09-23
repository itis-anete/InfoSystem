import VuetifyLoaderPlugin from 'vuetify-loader/lib/plugin'

export default {
  mode: 'spa',
  head: {
    title: 'InfoSystem',
    meta: [
      { charset: 'utf-8' },
      { name: 'viewport', content: 'width=device-width, initial-scale=1' },
      { hid: 'description', name: 'description', content: 'blabla' }
    ],
    link: [
      { rel: 'icon', type: 'image/x-icon', href: '/favicon.ico' },
      {
        rel: 'stylesheet',
        href: 'https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Material+Icons'
      }
    ]
  },
  loading: { color: '#52A8B6' },
  /*
   ** Global CSS
   */
  css: ['~/assets/style/app.styl'],

  /*
   ** Plugins to load before mounting the App
   */
  plugins: ['~/plugins/vuetify', '~/plugins/vuelidate'],

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
