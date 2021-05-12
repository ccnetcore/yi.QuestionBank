import myaxios from '@/utils/myaxios'
export default {
    getById(Id) {
        return myaxios({
            url: `/question/getActions?Id=${Id}`,
            method: 'get'
        })
    },
    getQuestion() {
        return myaxios({
            url: `/question/GetQuestion`,
            method: 'get'
        })
    },
    effectiveness(answer) {
        return myaxios({
            url: `/question/effectiveness?answer=${answer}`,
            method: 'get'
        })
    },
    getAll(pageSize, pageIndex, where) {
        return myaxios({
            url: `/question/getAll?where=${where}`,
            method: 'post',
            data: {
                pageSize: pageSize,
                pageIndex: pageIndex,
            }
        })
    },
    last() {
        return myaxios({
            url: `/question/Last`,
            method: 'get'
        })
    }
}