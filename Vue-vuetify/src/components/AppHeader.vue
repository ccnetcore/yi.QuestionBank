<template>
  <v-row>
    <v-col cols="2">
      <label>您好</label>
    </v-col>

    <v-col cols="2" offset="8">
      <label>{{user_name}}</label>
    </v-col>
  </v-row>
</template>
<script>
export default {
     data: () => ({
    user_name:""
    }),
  created() {
      this.initialize()
  },
  methods: {
    initialize() {
      var user = JSON.parse(localStorage.getItem("user"));
      this.user_name = user.user_name;
    },
  },
};
</script>
