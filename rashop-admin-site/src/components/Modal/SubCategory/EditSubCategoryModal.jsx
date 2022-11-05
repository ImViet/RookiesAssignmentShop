import { Modal, Button } from "react-bootstrap";
import EditSubCategoryForm from "../../Form/SubCategory/EditSubCategoryForm";

function EditSubCategoryModal({status, onClose, data}) {
  return (
    <Modal show={status}>
      <Modal.Header>
        <Modal.Title>Sửa danh mục</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <EditSubCategoryForm data={data} onSubmit={()=>onClose()}/>
      </Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={onClose}>Đóng</Button>
      </Modal.Footer>
    </Modal>
  );
}
export default EditSubCategoryModal;
