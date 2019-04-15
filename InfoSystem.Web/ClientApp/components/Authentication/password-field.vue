<template>
  <v-text-field
    outline
    v-model="localPassword"
    :append-icon="showPassword ? 'visibility_off' : 'visibility'"
    :type="showPassword ? 'text' : 'password'"
    label="Password"
    @keyup.enter="submit"
    @click:append="showPassword = !showPassword"
    :error-messages="passwordErrors"
    @input="v.password.$touch()"
    @blur="v.password.$touch()"
  />
</template>

<script>
import { validationMixin } from 'vuelidate'
import { required, minLength } from 'vuelidate/lib/validators'
export default {
  props: ['password', 'submit', 'v'],
  mixins: [validationMixin],
  data: () => ({
    showPassword: false
  }),
  computed: {
    passwordErrors() {
      const errors = []
      if (!this.v.password.$dirty) return errors
      !this.v.password.minLength && errors.push('Password must be at most 6 characters long')
      !this.v.password.required && errors.push('Password is required.')
      return errors
    },
    localPassword: {
      get() {
        return this.password
      },
      set(value) {
        this.$emit('update:password', value)
      }
    }
  }
}
</script>

<style>
</style>
