export default function({ store, redirect }) {
  if (store.state.user.token.length === 0) {
    return redirect('/authentication')
  }
  return true
}
