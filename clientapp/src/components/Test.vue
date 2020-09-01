<template>
  <div>
    <h1>Register</h1>

    <input 
      type = "email"
      name = "email"
      v-model = "email"
      placeholder = "email"/>
    
    <input 
      type = "password"
      name = "password"
      v-model = "password"
      placeholder = "password"/>

    <button @click = "register">Register</button>
  </div>
</template>

<script>

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
