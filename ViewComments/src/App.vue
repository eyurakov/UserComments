<template>
    <div id="app">
       <h1>Comments application</h1>
        <AddComment
                @add-comment="addComment"
                    />
        <hr>
        <CommentsList
                      v-if="comments.length"
                      v-bind:comments="comments"
                      @remove-comment="removeComment"
        />
        <p v-else>No comments!</p>
    </div>
</template>

<script>
    
    import CommentsList from '@/components/CommentsList'
    import AddComment from '@/components/AddComment'
    headers: {
        "Access-Control-Allow-Origin"
             }
    export default {
        name: 'app',
        data() {
            return {
                comments: []
            }
        },
        mounted() {
                       
            fetch('http://localhost:5001/Comments/GetComments')
                .then(response => response.json())
                .then(json => {
                    this.comments = json
                });
        },
        methods: {
            removeComment(id) {
                this.comments = this.comments.filter(c => c.id !== id)

            },
            addComment(comment) {
                this.comments.push(comment);
            }
        },
        
        components: {
           CommentsList, AddComment
        }
    };
</script>

<style>
    #app{
        font-family: 'Avenir', Arial, Helvetica, sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        text-align: center;
        color: #2c3e50;
        margin-top: 60px;
    }
</style>

