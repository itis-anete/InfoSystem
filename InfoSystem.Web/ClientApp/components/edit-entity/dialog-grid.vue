<template>
  <v-layout row wrap justify-center>
    <v-flex xs4>
      <v-card>
        <v-data-table v-if="currentValues" :headers="headers" :items="currentValues" item-key="id">
          <template v-slot:items="props">
            <td>
              <v-edit-dialog
                :return-value.sync="props.item.content"
                large
                lazy
                persistent
                @save="save(props.item)"
                @cancel="cancel"
              >
                <div>{{ props.item.content }}</div>
                <template v-slot:input>
                  <v-text-field
                    v-model="props.item.content"
                    label="Value"
                    single-line
                    counter
                    autofocus
                  ></v-text-field>
                </template>
              </v-edit-dialog>
            </td>
            <td class="text-xs-right">
              <v-edit-dialog
                :return-value.sync="props.item.attribute.name"
                large
                lazy
                persistent
                @save="save(props.item)"
                @cancel="cancel"
              >
                <div>{{ props.item.attribute.name }}</div>
                <template v-slot:input>
                  <v-select
                    :items="attributes"
                    item-text="name"
                    return-object
                    v-model="props.item.attribute"
                  ></v-select>
                </template>
              </v-edit-dialog>
            </td>
            <td class="text-xs-right">
              <v-edit-dialog
                :return-value.sync="props.item.attribute.valueType"
                large
                lazy
                persistent
                @save="save(props.item)"
                @cancel="cancel"
              >
                <div>{{ props.item.attribute.valueType }}</div>
                <template v-slot:input>
                  <v-select :items="types" v-model="props.item.attribute.valueType"></v-select>
                </template>
              </v-edit-dialog>
            </td>
          </template>
        </v-data-table>
      </v-card>
    </v-flex>
    <v-snackbar v-model="snack" :timeout="3000" :color="snackColor">
      {{ snackText }}
      <v-btn flat @click="snack = false">Close</v-btn>
    </v-snackbar>
  </v-layout>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'
export default {
  data() {
    return {
      snack: false,
      snackColor: '',
      snackText: '',
      headers: [
        {
          text: 'Value',
          align: 'left',
          sortable: false
        },
        { text: 'Attribute', sortable: false },
        { text: 'Type', value: 'type' }
      ],
      types: ['number', 'string', 'boolean']
    }
  },
  methods: {
    ...mapActions(['editValue']),
    save(item) {
      const value = {
        id: item.id,
        content: item.content,
        entityId: item.entityId,
        attributeId: item.attribute.id
      }
      this.editValue(value)
      this.setSnack('Data saved', 'success')
    },
    cancel() {
      this.setSnack('Canceled', 'error')
    },
    setSnack(text, color) {
      this.snack = true
      this.snackColor = color
      this.snackText = text
    }
  },
  computed: {
    ...mapGetters(['currentValues', 'attributes'])
  }
}
</script>

<style scoped>

</style>