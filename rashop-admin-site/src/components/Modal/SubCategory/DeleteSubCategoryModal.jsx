import { Button, Modal } from "react-bootstrap";
import {deleteSubCategoryAPI} from "../../../api/SubCategory";
function DeleteSubCategoryModal({status, onClose, data}) {
    function handleDelete(){
        console.log(data.subCategoryId)
        deleteSubCategoryAPI(data.subCategoryId)
        .then(() => {
          onClose();
            setTimeout(() => {
              alert("Xóa thành công!!!");
            }, 200);
        })
        .catch((err)=>{
          onClose();
          setTimeout(() => {
            alert("Xoá thất bại, có sản phẩm liên quan!!!");
          }, 200);
          console.log(err)});
    }
    return (
        <Modal
        show={status}
        backdrop="static"
      >
        <Modal.Header>
          <Modal.Title>Xóa danh mục:</Modal.Title>
        </Modal.Header>
        <Modal.Body>
         Bạn có chắc chắn muốn xóa? 
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={onClose}>
            Đóng
          </Button>
          <Button type="submit" onClick={handleDelete} variant="primary">Xóa</Button>
        </Modal.Footer>
      </Modal>
      
    );
  }
  export default DeleteSubCategoryModal;