export default function({ store, redirect }) {
  if (store.state.user.token.length === 0) {
    if (window.localStorage['token'] && window.localStorage['login']) {
      store.dispatch('authenticateFromLocalStorage')
      return true
    }
    return redirect('/authentication')
  }
  return true
}
