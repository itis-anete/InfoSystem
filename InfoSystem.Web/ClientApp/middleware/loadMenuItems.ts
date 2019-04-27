export default function({ store }) {
  if (store.state.menu.menuItems.length === 0) {
    return store.dispatch('menu/getMenuItems')
  }
  return true
}
