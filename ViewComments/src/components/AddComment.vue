<template>
    <form @submit.prevent="onSubmit">
        <input type="text" v-model="userName" />
        <input type="text" v-model="commentText" />
        <button type="submit">Create</button>
    </form>
</template>
<script>
    import axios from 'axios'
    headers: {
        'Access-Control-Allow-Origin'
    }

    export default {
        name: 'AddComment',
        data() {
            return {
                id: 0,
                userName: '',
                commentText: ''
            }

        },

        methods: {

            onSubmit() {

                if (this.commentText.trim(), this.userName.trim()) {
                    const newComment = {
                        id: 0,
                        userName: this.userName,
                        commentText: this.commentText,
                        completed: false
                    }
                    //http://localhost:5001/Comments/Add?userName=${this.userName}&commentText=${this.commentText}
                    const url = 'http://localhost:5001/Comments/Add?userName=' + this.userName + '&commentText=' + this.commentText
                    fetch(url)
                        .then(response => response.json())
                        .then(json => {
                            this.comments = json
                        });

                    //const requestOptions = {
                    //    method: "POST",
                    //    headers: {

                    //        'Access-Control-Allow-Origin': '*',
                    //        'Access-Control-Allow-Methods': 'GET, POST, OPTIONS, PUT, DELETE',
                    //        'Access-Control-Allow-Headers': 'Content-Type',
                    //        'Content-Type': 'application/json',
                    //        'Accept': 'application/json'
                    //    },
                    //    mode: "no-cors",
                    //    body:newComment
                    //};

                    //fetch('http://localhost:5001/Comments/Add', requestOptions)
                    //    .then(response => {
                    //        return response.text()
                    //    })
                    //    .then((data) => {
                    //        console.log(data)
                    //    })
                    //    .catch((error) => {
                    //        console.log(error)
                    //    })

                    this.$emit('get-comment')
                }
            }
        }
    }
</script>
<style scoped>
    form {
        display: flex;
    }

    input {
        width: 400px;
    }
</style>