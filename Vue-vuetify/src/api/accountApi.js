import myaxios from '@/utils/myaxios'
export default {
    login(user_name, password) {
        return myaxios({
            url: '/Account/login',
            method: 'post',
            data: {
                user_name: user_name,
                password: password
            }
        })
    },
    logOff() {
        return myaxios({
            url: '/Account/logOff',
            method: 'post',
        })
    },
    logged() {
        return myaxios({
            url: '/Account/logged',
            method: 'post',
        })
    },
    register(user_name, password) {
        return myaxios({
            url: '/Account/register',
            method: 'post',
            data: { user_name: user_name, password: password }
        })
    }

}