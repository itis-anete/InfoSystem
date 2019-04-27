export default function({ store, redirect }) {
  if (store.state.users.token.length === 0) {
    if (window.localStorage['token'] && window.localStorage['login']) {
      store.dispatch('users/authenticateFromLocalStorage')
      return true
    }
    return redirect('/authentication')
  }
  return true
}
