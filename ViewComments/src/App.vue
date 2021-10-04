<template>
    <div id="app">
       <h1>Comments application</h1>
        <AddComment
                @get-comment="getComments"
                    />
        <hr>
        <CommentsList
                      v-if="comments.length"
                      v-bind:comments="comments"
                      @remove-comment="removeComment"
                      @get-comment="getComments"
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

            this.getComments();
        },
        methods: {
            getComments() {
                fetch('http://localhost:5001/Comments/GetComments')
                    .then(response => response.json())
                    .then(json => {
                        this.comments = json
                    });
            },
            removeComment(id) {
                const url = 'http://localhost:5001/Comments/Delete?commentId=' + id
                fetch(url)
                    .then(response => {
                            return response.text()
                        })
                        .then((data) => {
                            console.log(data)
                        })
                        .catch((error) => {
                            console.log(error)
                        })
                this.getComments();
                //this.comments = this.comments.filter(c => c.id !== id)

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

