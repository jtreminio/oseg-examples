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

class FindPetsByTagsExample
{
    fun findPetsByTags()
    {
        ApiClient.accessToken = "YOUR_ACCESS_TOKEN"

        try
        {
            val response = PetApi().findPetsByTags(
                tags = listOf (
                    "tag_1",
                    "tag_2",
                ),
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling PetApi#findPetsByTags")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling PetApi#findPetsByTags")
            e.printStackTrace()
        }
    }
}
