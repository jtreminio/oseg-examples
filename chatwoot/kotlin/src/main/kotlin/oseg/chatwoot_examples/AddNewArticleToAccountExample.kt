package oseg.chatwoot_examples

import com.chatwoot.client.infrastructure.*
import com.chatwoot.client.apis.*
import com.chatwoot.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class AddNewArticleToAccountExample
{
    fun addNewArticleToAccount()
    {
        ApiClient.apiKey["api_access_token"] = "USER_API_KEY"

        val articleCreateUpdatePayload = ArticleCreateUpdatePayload(
            meta = Serializer.moshi.adapter<Map<String, Any>>().fromJson("""
                {
                    "description": "article description",
                    "tags": [
                        "article_name"
                    ],
                    "title": "article title"
                }
            """)!!,
        )

        try
        {
            val response = HelpCenterApi().addNewArticleToAccount(
                accountId = 0,
                portalId = 0,
                _data = articleCreateUpdatePayload,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling HelpCenterApi#addNewArticleToAccount")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling HelpCenterApi#addNewArticleToAccount")
            e.printStackTrace()
        }
    }
}
