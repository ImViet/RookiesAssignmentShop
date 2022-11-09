import { Modal, Button } from "react-bootstrap";
import EditCategoryForm from "../../Form/Category/EditCategoryForm";
import { putCategoryAPI } from "../../../api/Category";
function EditCategoryModal({status, onClose, data}) {
  const handleSubmit = (category)=>{
    putCategoryAPI(category).then(()=>{
      onClose();
      setTimeout(() => {
        alert("Sửa thành công!!!");
      }, 200);
    }).catch((err)=>{
      setTimeout(() => {
        alert("Sửa thất bại!!!");
      }, 200);
      console.log(err)});
  }
  return (
    <Modal size="lg" show={status}>
      <Modal.Header>
        <Modal.Title>Sửa danh mục</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <EditCategoryForm data={data} onSubmit={handleSubmit}/>
      </Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={onClose}>Đóng</Button>
      </Modal.Footer>
    </Modal>
  );
}
export default EditCategoryModal;
