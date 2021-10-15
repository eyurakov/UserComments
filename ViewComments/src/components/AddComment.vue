<template>
    <form @submit.prevent="onSubmit">
        <div class="UserName">
            <label>User: </label>
            <br>
            <input type="text" v-model="userName" title="Enter name of USer" />

        </div>
        <br>
        <div class="Comment">
            <label>Comment: </label>
            <br>
            <div class="textarea">
                <textarea style="width:200px; height:100px;" type="text" v-model="commentText" />
            </div>
        </div>

        <div v-if="errors.length > 0">
            <ul>
                <li v-for="error in errors" style="color:red">{{error}}</li>
            </ul>
        </div>

        <div class="button">
            <button type="submit">Create</button>
        </div>
    </form>
</template>

<script>
    export default {
        name: 'AddComment',
        data() {
            return {
                id: 0,
                userName: '',
                commentText: '',
                errors: []
            }
        },
        methods: {
            onSubmit() {

                this.errors = [];

                if (this.userName.trim() == '')
                    this.errors.push("User field is required");

                if (this.commentText.trim() == '')
                    this.errors.push("Comment field is required");

                if (this.userName.trim().length < 1)
                    this.errors.push("User must be more then 3 characters");

                if (this.commentText.trim().length < 1)
                    this.errors.push("Comment must be more then 15 characters");

                if (this.errors.length == 0) {
                    const newComment = {
                        userName: this.userName,
                        commentText: this.commentText
                    }
                    const requestOptions = {
                        method: "POST",
                        headers: {
                            'Content-Type': 'application/json'
                        },
                        body: JSON.stringify(newComment)
                    };

                    fetch('http://localhost:5001/Comments/AddPost', requestOptions)
                        .then(response => {
                            return response.text()
                        })
                        .then((data) => {
                            if (data)
                                this.$emit('get-comments')
                            console.log(data)
                        })
                        .catch((error) => {
                            console.log(error)
                        })
                }
            }
        }
    }
</script>

<style scoped>
    UserName {
        align-content: center;
        display: flex;
    }

    Comment {
        align-content: center;
        display: flex;
    }

    button {
        margin-top: 20px;
    }

    li {
        list-style-type: none;
        font-size: 10px;
    }
</style>