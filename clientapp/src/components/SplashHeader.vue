<template>
    <div class="root">
        <b-container fluid="lg">
            <h1 class="header">Knowledge Base</h1>
            <p class="pt-2">
                For current progress and plans, check out the
                <a href="https://trello.com/b/wAvuoyNi/knowledge-base" target="_blank" rel="noopener">Trello board</a>.
                Use 'taskkill -F -IM node.exe' if launching front-end through VS 2019 via another command line
                after stopping within VS 2019 or localhost:8080 will still be bound to a running Vue.js instance. Otherwise,
                if only running front-end via 'npm run serve' through command line, just use 'Ctrl+c' to stop server. Updates
                to front-end hot reload, so no need to stop and restart every time files are changed/created to see changes.
            </p>
            <h4 class="text-left">Iteration 2 Plans</h4>
            <ul>
                <li>Replace back-end with Django Rest Framework</li>
                <li>Migrate into separate repositories for Vue 2 and Django Rest Framework</li>
                <li>Use proper dates with PostgreSQL and back-end</li>
                <li>Use Docker and Kubernetes and deploy on AWS</li>
            </ul>
        </b-container>
        <KnowledgeItems/>
    </div>

</template>

<script>
    import KnowledgeItems from "./KnowledgeItems"

    export default {
        name: 'SplashHeader',
        components: {
            KnowledgeItems
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    .header {
        text-align: center;
        border-bottom: 2px solid #d8d8d8;
        padding-bottom: 10px;
        padding-top: 10px;
    }
</style>
