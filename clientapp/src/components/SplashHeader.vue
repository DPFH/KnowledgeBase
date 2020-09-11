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
            <h4 class="text-left">Iteration 1 Plans</h4>
            <ul>
                <li>Create a home page</li>
                <li>Create REST endpoints in .NET part of application and send sample JSON back</li>
                <li>Create front-end tabs/drop-downs that render the JSON</li>
                <li>Hook up back end to PostgreSQL</li>
                <li>deploy a PostgreSQL server on AWS</li>
            </ul>
            <p>
                Lorem Ipsum is simply dummy text of the printing and typesetting industry.
                Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,
                when an unknown printer took a galley of type and scrambled it to make a
                type specimen book. It has survived not only five centuries, but also the leap
                into electronic typesetting, remaining essentially unchanged. It was popularised
                in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages,
                and more recently with desktop publishing software like Aldus PageMaker
                including versions of Lorem Ipsum.
            </p>
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
