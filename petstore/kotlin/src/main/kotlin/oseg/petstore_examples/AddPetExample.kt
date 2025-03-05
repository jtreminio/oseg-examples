package oseg.petstore_examples

import org.openapitools.client.infrastructure.*
import org.openapitools.client.apis.*
import org.openapitools.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class AddPetExample
{
    fun addPet()
    {
        ApiClient.accessToken = "YOUR_ACCESS_TOKEN"

        val category = Category(
            id = 12345,
            name = "Category_Name",
        )

        val tags1 = Tag(
            id = 12345,
            name = "tag_1",
        )

        val tags2 = Tag(
            id = 98765,
            name = "tag_2",
        )

        val tags = arrayListOf<Tag>(
            tags1,
            tags2,
        )

        val pet = Pet(
            name = "My pet name",
            photoUrls = listOf (
                "https://example.com/picture_1.jpg",
                "https://example.com/picture_2.jpg",
            ),
            id = 12345,
            status = Pet.Status.available,
            category = category,
            tags = tags,
        )

        try
        {
            val response = PetApi().addPet(
                pet = pet,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling PetApi#addPet")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling PetApi#addPet")
            e.printStackTrace()
        }
    }
}
